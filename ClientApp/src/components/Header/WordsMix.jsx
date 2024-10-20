import { useState, useEffect } from "react"
import styles from "./header.module.less"

const words = [
    {
        uaWord: 'Будинок',
        enWord: 'House',
        frWord: 'Maison',
        polWord: 'Dom'
    },
    {
        uaWord: "Навчання",
        enWord: "Study",
        frWord: "Étude",
        polWord: "Nauka"
    },
    {
        uaWord: "Успіх",
        enWord: "Success",
        frWord: "Succès",
        polWord: "Sukces"
    },
    {
        uaWord: "Життя",
        enWord: "Life",
        frWord: "Vie",
        polWord: "Życie"
    }
]

export default function WordsMix() {

    const [currentWords, setCurrentWords] = useState(words[0])

    useEffect(() => {
        let index = 0;
        const intervalId = setInterval(() => {
            setCurrentWords(words[index]);
            index = (index + 1) % words.length;
        }, 20000);

        return () => clearInterval(intervalId);
    }, []);

    return (
        <>
            <ul className={styles.header__wordsTranslated}>
                <li>А ви знали?</li>
                <li>{currentWords.uaWord}</li>
                <li>{currentWords.enWord}</li>
                <li>{currentWords.polWord}</li>
                <li>{currentWords.frWord}</li>
            </ul>
        </>
    )
}
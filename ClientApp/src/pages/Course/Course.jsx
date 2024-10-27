import { useParams } from 'react-router-dom';
import DescriptionBlock from './DescriptionBlock/DescriptionBlock';
import Comments from './Comments/Comments';
import Recommends from './Recommends/Recommends';

const course = {
    id: 1,
    title: "Фіктивний Курс",
    description: "Цей курс є фіктивним для демонстраційних цілей.",
    level: "Елементарний",
    language: "Українська",
    numberLessons: 30,
    cost: 0,
    image: '/src/img/Content/AboutService.png'
}

//TODO: замінити фіктивний курс на отримання курсу по айди з серверу + додати на сервері функціонал з коментарями +  додати та підлюкичити систему схожих курсів

export default function Course() {

    const { id } = useParams();
    return (
        <>
            <section><DescriptionBlock course={course} /></section> 
            <div style={{ display: 'flex' }}>
                <section><Comments /></section>
                <section><Recommends /></section>
            </div>
        </>
    );
}
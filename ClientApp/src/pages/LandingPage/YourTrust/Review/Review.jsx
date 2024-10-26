import { useState } from 'react';
import { useTheme } from '/src/Hooks/ThemeContext'
import styles from './reviews.module.less'

export default function Review({ title, text, user, date, grade }) {
    const { theme } = useTheme();
    return (
        <div className={`${styles.review} ${theme === 'dark' ? styles.review_dark : styles.review_light}`}>
            <h5 className={styles.title}>{title}</h5>
            <p className={styles.text}>{text}</p>
            <p className={styles.user}>{user}, <span className={styles.date}>{date}</span></p>
            <div className={`${styles.grade} ${theme === 'dark' ? styles.grade_dark : styles.grade_light}`}>
                {Array.from({ length: 5 }, (_, index) => (
                    index < grade ? (
                        <span key={index} className={styles.goldStar}>★</span>
                    ) : (
                        <span key={index} className={styles.greyStar}>★</span>
                    )
                ))}
            </div>
        </div>
    );
}
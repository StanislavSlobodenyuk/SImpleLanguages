import styles from "./styles.module.less"

export default function ThirdStep({ formData, onChange, sendData, onNext, onPrev }) {
    const isScheduleEmpty =
        formData.studySchedule &&
        !formData.studySchedule.time &&
        Array.isArray(formData.studySchedule.days) &&
        formData.studySchedule.days.length === 0;

    const handleInputChange = (name, value) => {
        if (name === "studyScheduleTime") {
            onChange("studySchedule", {
                ...formData.studySchedule,
                time: value,
            });
        } else if (name === "studyScheduleDays") {
            onChange("studySchedule", value);
        }
    };

    return (
        <div className={styles.registerContainer}>
            <h2 className={styles.formTitle}>Крок 3: Налаштування розкладу.</h2>
            <div className={styles.textThirdStep}>Налаштуйте ваш графік навчання та виконуйте тиждневу норму для отримання додаткових нагород</div>
            <form className={styles.form} action="" method="post">
                <div className={styles.formBlock}>
                    <label className={styles.label} htmlFor="studyScheduleTime">Скільки часу ви б хотіли навчатись?</label>
                    <select
                        className={styles.input}
                        name="studyScheduleTime"
                        value={formData.studySchedule.time}
                        onChange={(e) => handleInputChange(e.target.name, e.target.value)}
                    >
                        <option value="">Час</option>
                        <option value="20">20 хвилин</option>
                        <option value="30">30 хвилин</option>
                        <option value="40">40 хвилин</option>
                        <option value="50">50 хвилин</option>
                        <option value="60">1 годину</option>
                        <option value="120">2 години</option>
                    </select>
                </div>
                <div className={styles.checkboxLabel}>Виберіть дні для навчання</div>
                <div className={styles.formBlockcheckbox}>
                    {["Понеділок", "Вівторок", "Середа", "Четверг", "П'ятниця", "Субота", "Неділя"].map((day, index) => (
                        <div key={index} className={styles.formBlock}>
                            <input
                                type="checkbox"
                                id={`studyScheduleDays-${index}`}
                                name="studyScheduleDays"
                                value={day}
                                checked={formData.studySchedule.days.includes(day)}
                                onChange={(e) =>
                                    handleInputChange(e.target.name, {
                                        ...formData.studySchedule,
                                        days: e.target.checked
                                            ? [...formData.studySchedule.days, day]
                                            : formData.studySchedule.days.filter(d => d !== day),
                                    })
                                }
                            />
                            {day}
                        </div>
                    ))}
                </div>
            </form>
            <div className={styles.buttons}>
                <div onClick={onPrev}>Повернутись</div>
                {isScheduleEmpty ? (
                    <div className={styles.formButton} onClick={() => { sendData(); onNext(); }}>Пропустити</div>
                ) : (
                    <div onClick={() => { sendData(); onNext(); }}>Далі</div>
                )}
            </div>
        </div>
    )
}
// список для всіх фільтрів на проекті
const filters = [
    {
        key: 'language',
        options: [
            { value: 'all', label: 'Мова' },
            { value: 'english', label: 'Англійська' },
            { value: 'ukrainian', label: 'Українська' },
            { value: 'polish', label: 'Польська' },
            { value: 'cheska', label: 'Чешська' },
        ],
    },

    {
        key: 'level',
        options: [
            { value: 'all', label: 'Рівень' },
            { value: 'beginner', label: 'A1: Початковий' },
            { value: 'elementary', label: 'A2: Базовий' },
            { value: 'intermediate', label: 'B1: Середній' },
            { value: 'upperntermediate', label: 'B2: Вище-середнього' },
            { value: 'advanced', label: 'C1: Просунутий' },
            { value: 'proficient', label: 'C2: Досвідчений' },
        ],
    },

    {
        key: 'numberLessons',
        options: [
            { value: 'all', label: 'Кількість уроків' },
            { value: '1-50', label: '1-50' },
            { value: '51-100', label: '51-100' },
            { value: '101-200', label: '101-200' },
            { value: '200+', label: '200+' },
        ],
    },

    {
        key: 'cost',
        options: [
            { value: 'all', label: 'Доступ' },
            { value: 'free', label: 'Безплатний' },
            { value: 'paid', label: 'Платний' },
        ],
    },

    {
        key: 'futureCourses',
        label: 'Показати курсі в розробці?',
        options: [
            { value: false, label: 'Не показувати' },
            { value: true, label: 'Показати' },
        ],
    },

    {
        key: 'completeCourses',
        label: 'Показати активні курси?',
        options: [
            { value: false, label: 'Не показувати' },
            { value: true, label: 'Показати' },
        ],
    },
    // more filters
]

// список фільтрів для конкретного проекту
export const CourseFilter = {
    language: filters.find(item => item.key === 'language'),
    level: filters.find(item => item.key === 'level'),
    numberLessons: filters.find(item => item.key === 'numberLessons'),
    cost: filters.find(item => item.key === 'cost'),
    futureCourses: filters.find(item => item.key === 'futureCourses'),
    completeCourses: filters.find(item => item.key === 'completeCourses')
}
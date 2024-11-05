// список для всіх фільтрів на проекті
const filters = [
    {
        key: 'language',
        options: [
            { value: 'All', label: 'Мова' },
            { value: 'English', label: 'Англійська' },
            { value: 'Ukrainian', label: 'Українська' },
            { value: 'Polish', label: 'Польська' },
            { value: 'Cheska', label: 'Чешська' },
        ],
    },

    {
        key: 'level',
        options: [
            { value: 'All', label: 'Рівень' },
            { value: 'Beginner', label: 'A1: Початковий' },
            { value: 'Elementary', label: 'A2: Базовий' },
            { value: 'Intermediate', label: 'B1: Середній' },
            { value: 'Upperntermediate', label: 'B2: Вище-середнього' },
            { value: 'Advanced', label: 'C1: Просунутий' },
            { value: 'Proficient', label: 'C2: Досвідчений' },
        ],
    },

    {
        key: 'numberLessons',
        options: [
            { value: 'All', label: 'Кількість уроків' },
            { value: '1-50', label: '1-50' },
            { value: '51-100', label: '51-100' },
            { value: '101-200', label: '101-200' },
            { value: '200+', label: '200+' },
        ],
    },

    {
        key: 'cost',
        options: [
            { value: 'All', label: 'Доступ' },
            { value: 'Free', label: 'Безплатний' },
            { value: 'Paid', label: 'Платний' },
        ],
    },

    {
        key: 'inDevelopment',
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
    futureCourses: filters.find(item => item.key === 'inDevelopment'),
    completeCourses: filters.find(item => item.key === 'completeCourses')
}
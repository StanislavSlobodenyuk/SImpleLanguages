import { useState } from 'react'
import SearchBar from './../../components/Common/SearchBar/SearcBar'
import Filter from './../../components/Common/Filter/Filter'
import { CourseFilter } from './../../components/Common/Filter/filterData'
import Sorting from './../../components/Common/Sorting/Sorting'
import CourseCard from '/src/components/Common/CourseCard/CourseCard'
import MyPagination from "./../../components/Common/MyPagination/MyPagination";
import styles from './courses.module.less'

const allCourses = [
    // фіктивні данні для відображення вебу потім видаляться 
    {
        id: 1,
        title: 'Основи англійської мови',
        description: 'Цей курс охоплює основи англійської мови для початківців.',
        language: 'english',
        level: 'beginner',
        numberLessons: 30,
        cost: 0,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 2,
        title: 'Англійська для туристів',
        description: 'Курс з англійської для тих, хто подорожує.',
        language: 'english',
        level: 'elementary',
        numberLessons: 25,
        cost: 75,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 3,
        title: 'Поглиблене вивчення української мови',
        description: 'Цей курс призначений для тих, хто хоче покращити свої знання української.',
        language: 'ukrainian',
        level: 'intermediate',
        numberLessons: 40,
        cost: 120,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 4,
        title: 'Основи польської мови',
        description: 'Вивчайте польську мову з нуля.',
        language: 'polish',
        level: 'beginner',
        numberLessons: 30,
        cost: 90,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 5,
        title: 'Чеська мова для початківців',
        description: 'Цей курс є ідеальним для новачків у вивченні чеської мови.',
        language: 'cheska',
        level: 'beginner',
        numberLessons: 20,
        cost: 80,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 6,
        title: 'Польська мова для туристів',
        description: 'Вивчайте польську для подорожей по Польщі.',
        language: 'polish',
        level: 'elementary',
        numberLessons: 30,
        cost: 85,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 7,
        title: 'Просунутий курс англійської мови',
        description: 'Поглиблене вивчення англійської для досвідчених.',
        language: 'english',
        level: 'advanced',
        numberLessons: 35,
        cost: 150,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 8,
        title: 'Середній курс української мови',
        description: 'Для тих, хто вже знає основи української мови.',
        language: 'ukrainian',
        level: 'intermediate',
        numberLessons: 30,
        cost: 110,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 9,
        title: 'Англійська для бізнесу',
        description: 'Цей курс призначений для тих, хто хоче вивчити англійську для роботи.',
        language: 'english',
        level: 'upperntermediate',
        numberLessons: 40,
        cost: 130,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 10,
        title: 'Чеська для бізнесу',
        description: 'Вивчайте чеську мову для роботи у Чехії.',
        language: 'cheska',
        level: 'upperntermediate',
        numberLessons: 30,
        cost: 140,
        image: '/src/img/Content/AboutService.png'
    },
    // фіктивні данні для відображення вебу потім видаляться 
    // TODO: запит з серверу на всі курси 
];

export default function Courses() {
    const [filteredCourses, setFilteredCourses] = useState(allCourses)
    const [displayedCourses, setDisplayedCourses] = useState([])
    const [activePage, setActivePage] = useState(1);

    const handleFilterChange = (selectedFilters) => {
        let filtered = allCourses;

        // Фільтрація за мовою
        if (selectedFilters.language && selectedFilters.language !== 'all') {
            filtered = filtered.filter(course => course.language === selectedFilters.language);
        }

        // TODO: інші перевірки на змінення фільтру 

        setFilteredCourses(filtered); // TODO: замість відправки filtered выдправка выдповіді з сервера щодо нових курсів 
        setDisplayedCourses([]);
        setActivePage(1);
    };


    return (
        <>
            <section className="block__container">
                <h2>Всі курси</h2>
                <SearchBar id={"SearchCourse"} />
                <Filter filters={CourseFilter} onFilterChange={handleFilterChange} />
                <Sorting />
                <MyPagination items={filteredCourses} itemsPerPage={9} onPageChange={setDisplayedCourses} activePage={activePage} setActivePage={setActivePage} />
                <div className={styles.courses}>
                    {
                        displayedCourses.map(course => (
                            <CourseCard course={course} />
                        ))
                    }
                </div>
                <MyPagination items={filteredCourses} itemsPerPage={9} onPageChange={setDisplayedCourses} activePage={activePage} setActivePage={setActivePage} />
            </section>
        </>
    );
}
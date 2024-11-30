import { useState, useEffect } from 'react';
import { CourseFilter } from './../../components/Common/Filter/filterData';
import { FetchCourses } from '/src/api/CourseApi/CourseApi.js';
import SearchBar from './../../components/Common/SearchBar/SearcBar';
import Filter from './../../components/Common/Filter/Filter';
import Sorting from './../../components/Common/Sorting/Sorting';
import CourseCard from '/src/components/Common/CourseCard/CourseCard';
import MyPagination from "./../../components/Common/MyPagination/MyPagination";
import styles from './courses.module.less';

export default function Courses() {
    const [courses, setCourses] = useState([]);
    const [error, setError] = useState(null);
    const [activePage, setActivePage] = useState(1);
    const [itemsPerPage] = useState(9);
    const [searchTerm, setSearchTerm] = useState('');
    const [selectedFilters, setSelectedFilters] = useState({
        language: 'All',
        level: 'All',
        numberLessons: 'all',
        cost: 'all',
        inDevelopment: false,
        completeCourses: false,
    });

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await FetchCourses({
                    searchTitle: searchTerm,
                    language: selectedFilters.language,
                    level: selectedFilters.level,
                    lessonCount: selectedFilters.numberLessons,
                    cost: selectedFilters.cost,
                    inDevelopment: selectedFilters.inDevelopment
                })
                
                setCourses(data)
            } catch (error) {
                setError('Failed to fetch courses')
            }
        };

        fetchData()
    }, [selectedFilters, searchTerm]);

    if (error) {
        return <div>{error}</div>;
    }

    const indexOfLastItem = activePage * itemsPerPage;
    const indexOfFirstItem = indexOfLastItem - itemsPerPage;
    const currentCourses = courses.slice(indexOfFirstItem, indexOfLastItem);

    return (
        <section className="block__container">
            <h2>Всі курси</h2>
            <SearchBar id={"SearchCourse"} onSearchChange={setSearchTerm} />
            <Filter filters={CourseFilter} selectedFilters={selectedFilters} onFilterChange={setSelectedFilters} />
            <Sorting />
            <MyPagination
                items={courses}
                itemsPerPage={itemsPerPage}
                onPageChange={setActivePage}
                activePage={activePage}
            />
            <div className={styles.courses}>
                {currentCourses.length !== 0
                    ? (currentCourses.map(course => (
                        <CourseCard key={course.id} course={course} />
                    )))
                    : (<div>Курсів по данним фільтам не знайдено</div>)}
            </div>
            <MyPagination
                items={courses}
                itemsPerPage={itemsPerPage}
                onPageChange={setActivePage}
                activePage={activePage}
            />
        </section>
    );
}

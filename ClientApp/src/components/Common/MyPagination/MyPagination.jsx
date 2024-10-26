import Pagination from 'react-js-pagination';
import { useState, useEffect } from 'react';
import { useTheme } from '/src/Hooks/ThemeContext'
import styles from './pagination.module.less';

export default function MyPagination({ items, itemsPerPage = 9, onPageChange, activePage, setActivePage }) {
    const { theme } = useTheme();

    useEffect(() => {
        const indexOfLastItem = activePage * itemsPerPage;
        const indexOfFirstItem = indexOfLastItem - itemsPerPage;
        const currentItems = items.slice(indexOfFirstItem, indexOfLastItem);
        onPageChange(currentItems);
    }, [activePage, items, itemsPerPage, onPageChange]);

    const handlePageChange = (pageNumber) => {
        setActivePage(pageNumber);
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        })
    };

    return (
        <div>
            <Pagination
                activePage={activePage}
                itemsCountPerPage={itemsPerPage}
                totalItemsCount={items.length}
                pageRangeDisplayed={5}
                onChange={handlePageChange}
                prevPageText={'Prev'}
                firstPageText={<span className={activePage < 3 ? styles.isDisabled : ''}>First</span>}
                lastPageText={<span className={activePage > (Math.ceil(items.length / itemsPerPage) - 3) ? styles.isDisabled : ''}>Last</span>}
                nextPageText={'Next'}
                innerClass={styles.pagination}
                itemClass={styles.paginationItem}
                linkClass={`${styles.paginationLink} ${theme === 'dark' ? styles.paginationLink_dark : styles.paginationLink_light}`}
                activeClass={theme === 'dark' ? styles.activePage_dark : styles.activePage_light}
                linkClassFirst={styles.pagination_first}
                linkClassLast={styles.pagination_last}
                linkClassNext={styles.pagination_next}
                linkClassPrev={styles.pagination_prev}
            />
        </div>
    );
}

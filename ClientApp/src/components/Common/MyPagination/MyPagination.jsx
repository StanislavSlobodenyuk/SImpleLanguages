import Pagination from 'react-js-pagination';
import { useTheme } from '/src/Hooks/ThemeContext';
import styles from './pagination.module.less';

export default function MyPagination({ items, itemsPerPage = 9, onPageChange, activePage }) {
    const { theme } = useTheme();

    const scrollToTop = () => {
        const scrollStep = -window.scrollY / 15;
        const scrollInterval = setInterval(() => {
            if (window.scrollY !== 0) {
                window.scrollBy(0, scrollStep);
            } else {
                clearInterval(scrollInterval);
            }
        }, 15);
    }

    const handlePageChange = (pageNumber) => {
        onPageChange(pageNumber);
        scrollToTop();
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

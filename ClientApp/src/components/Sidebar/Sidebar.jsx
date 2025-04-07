import { Link } from 'react-router-dom';
import { useState } from 'react';
import { menuLinks } from '../Common/Menu/menuData';
import { sociable } from '../Common/Sociable/sociableData';
import Maintitle from '../Common/MainTitle/MainTitle';
import Menu from '../Common/Menu/Menu';
import Sociable from '../Common/Sociable/Sociable';
import Button from '../Common/Button/Button';
import styles from './sidebar.module.less';

export default function Sidebar({ authenticated }) {
    const [isOpen, setIsOpen] = useState(true);

    const toggleDropdown = () => {
        setIsOpen(!isOpen);
    };

    return (
        <aside>
            <div className={styles.sidebarContainer}>
                <Maintitle location="sidebar" />
                {authenticated === true
                    ? (<div className={styles.sidebarMenu}>
                        <ul className={styles.menuLinks}>
                            <Menu {...menuLinks[0]} />
                            <div onClick={toggleDropdown}>
                                <Menu {...menuLinks[1]} />
                            </div>
                            <ul className={`${styles.dropdownMenu} ${isOpen ? styles.show : ''}`}>
                                <p className={styles.menuAdditionalText}>Курс: English elementary</p>
                                <Link to={"/courses"} className={styles.menuChangeCourse}>Натисніть для зміни курсу</Link>
                                <Menu {...menuLinks[2]} />
                                <Menu {...menuLinks[3]} />
                                <Menu {...menuLinks[4]} />
                            </ul>
                            <Menu {...menuLinks[5]} />
                            <Menu {...menuLinks[6]} />
                            <Menu {...menuLinks[7]} />
                        </ul>
                    </div>)
                    : (<div className={styles.sidebarButtons}>
                        <Link to="/login"> <Button>Увійти</Button></Link>
                    </div>)
                }
                <div className={styles.sidebarSociables}>
                    <Sociable {...sociable[0]} />
                    <Sociable {...sociable[1]} />
                    <Sociable {...sociable[2]} />
                    <Sociable {...sociable[3]} />
                </div>
                <div className={styles.sidebarPrivacy}>
                    <div>© Simple Languages </div>
                    <div>Всі права захищені</div>
                </div>
            </div>
        </aside>
    )
}
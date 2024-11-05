import { useState, useEffect } from 'react';
import styles from './filter.module.less';

export default function Filter({ filters, selectedFilters, onFilterChange }) {
    const handleChange = (key, value) => {
        const newSelectedFilters = { ...selectedFilters, [key]: value };
        onFilterChange(newSelectedFilters); // Callback для обновления фильтров
    };

    return (
        <div className={styles.filters}>
            {Object.keys(filters).map((key) => {
                const filter = filters[key];
                return (
                    <div key={key} className={styles.filter}>
                        <label className={styles.label}>{filter.label}</label>
                        <select
                            className={styles.select}
                            value={selectedFilters[key]}
                            onChange={(e) => handleChange(key, e.target.value)}
                        >
                            {filter.options.map(option => (
                                <option key={option.value} value={option.value} className={styles.option}>
                                    {option.label}
                                </option>
                            ))}
                        </select>
                    </div>
                );
            })}
        </div>
    );
}

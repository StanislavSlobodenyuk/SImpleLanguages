import styles from './../lessonTheory.module.less'

export default function Imageblock({ block }) {
    const images = block.images
    return (
        <div>
            {block.title && <p className={styles.theoryBlockTitle}>{block.title}</p>}
            <div>
                {images && images.length > 0 ? (
                    images.map((image) => (
                        <div className={styles.theoryImage} key={image.id}>
                            <img src={image.url} alt={image.alt}></img>
                        </div>
                    ))
                ) : (<p>Зображення не знайдено</p>)
                }
            </div>
        </div>
    );
}
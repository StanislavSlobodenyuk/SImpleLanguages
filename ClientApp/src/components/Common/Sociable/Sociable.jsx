export default function Sociable({ alt, src, link }) {
    return (
        <>
            <a href={link}>
                <img src={src} alt={alt} />
            </a>
        </>
    )
}
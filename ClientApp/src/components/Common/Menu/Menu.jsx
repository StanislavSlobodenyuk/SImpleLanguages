export default function Menu({ id, text, link }) {
    return (
        <li>
            <a href={link} id={id}>{text}</a>
        </li>
    )
}
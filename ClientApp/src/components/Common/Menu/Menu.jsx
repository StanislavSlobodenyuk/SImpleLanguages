import { Link } from 'react-router-dom'

export default function Menu({ id, text, link }) {
    return (
        <li>
            <Link to={link} id={id}>
                {text}
            </Link>
        </li>
    )
}
import ImageWithCaption from '../../../components/Common/ImageWithCaption/ImageWirhCaption.jsx'
import { courses } from './coursesData.js'

export default function OutCourses() {
    return (
        <div className={"block-container"}>
            <h2>Наші курси</h2>
            <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                {
                    courses.map((course, index) => (
                        <ImageWithCaption key={index} {...course} location={'LandingPage'} />
                    ))
                }
            </div>
        </div>
    )
}
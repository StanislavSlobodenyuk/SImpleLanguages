import AboutService from './AboutService/AboutService'
import WayToTeach from './WayToTeach/WayToTeach'
import OutCourses from './OutCourses/OutCourses'
import OutTasks from './OutTasks/OutTasks'
import YourTrust from './YourTrust/YourTrust'


export default function LandingPage() {

    return (
        <>
            <section> <AboutService /></section>
            <section> <WayToTeach /></section>
            <section> <OutCourses /></section>
            <section> <OutTasks /></section>
            <section><YourTrust /></section>
        </>
    )
}
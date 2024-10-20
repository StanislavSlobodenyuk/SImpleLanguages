import Header from "./components/Header/Header"
import Footer from "./components/Footer/Footer"
import Sidebar from "./components/Sidebar/Sidebar"
import { ThemeProvider } from "./components/Hooks/ThemeContext"

export default function App() {
    return (
        <>
            <ThemeProvider>
                <Sidebar />
                <div className="content__container">
                    <Header />
                    <main>
                        lorem10000
                    </main>
                    <Footer />
                </div>
            </ThemeProvider>
        </>
    )
}


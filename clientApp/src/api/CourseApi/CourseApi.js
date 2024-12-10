import axios from "axios";

export const FetchCourses = async ({ searchTitle, language, level, lessonCount, cost, inDevelopment }) => {
    try {
        const response = await axios.get('http://localhost:5000/api/course/get-all', {
            params: {
                searchTitle,
                language,
                level,
                lessonCount,
                cost,
                inDevelopment
            }
        });

        if (response.data && response.data.length === 0) {
            return [];
        };

        return response.data;
    } catch (error) {
        console.log('Server error');
        throw error;
    };
}

export const FetchCourse = async ({ courseId }) => {
    try {
        courseId = typeof courseId === 'string' ? parseInt(courseId, 10) : courseId;
        const response = await axios.get(`http://localhost:5000/api/course/${courseId}`);
        if (response.data === null) {
            return {};
        };

        return response.data;
    } catch (error) {
        console.log('Server error');
        throw error;
    };
}

export const FetchCourseModules = async ({ courseId }) => {
    try {
        courseId = typeof courseId === 'string' ? parseInt(courseId, 10) : courseId;
        const response = await axios.get(`http://localhost:5000/api/coursemodule/get-all${courseId}`);

        if (response.data && response.data.length === 0) {
            return [];
        };

        return response.data;

    } catch (error) {
        console.log('Server error');
        throw error;
    };
}

export const FetchQuestion = async ({ lessonId }) => {
    try {
        lessonId = typeof lessonId === 'string' ? parseInt(lessonId, 10) : lessonId;
        const response = await axios.get(`http://localhost:5000/api/question/get-all${lessonId}`);

        if (response.data === null) {
            throw error;
        };

        return response.data;

    } catch (error) {
        console.log('Server error');
        throw error;
    };
}


using Common.Enum;
using Common.Response;
using Dal.Interfaces;
using Domain.Entity.Content.Lessons;
using Service.Interfaces;
using System.Reflection;

namespace Service.Implementations
{
    public class ModuleLessonService : IModuleLessonService
    {
        private readonly IModuleLessonsRepository _moduleLessonsRepository;

        public ModuleLessonService( IModuleLessonsRepository moduleLessonsRepository)
        { 
            _moduleLessonsRepository = moduleLessonsRepository;
        }

        public async Task<BaseResponse<ModuleLessons>> CreateModule(string title, string description, bool isAvailable)
        {
            if (string.IsNullOrEmpty(title)) 
            {
                return new BaseResponse<ModuleLessons>()
                {
                    Description = "Unable to create course, error when entering parameters",
                    StatusCode = MyStatusCode.BadRequest
                };
            }
            

            try
            {
                var newModule = new ModuleLessons(title, isAvailable, description);

                bool result = await _moduleLessonsRepository.Create(newModule);

                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<ModuleLessons>("Error creating new module");

                return BaseResponseHelper.HandleSuccessfulRequest(newModule);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<ModuleLessons>("Error create new module");
            }
        }
        public async Task<BaseResponse<bool>> DeleteModule(int moduleId)
        {
            var existingModule = await _moduleLessonsRepository.GetById(moduleId);

            if (existingModule == null)
            {
                return BaseResponseHelper.HandleNotFound<bool>("Module not found");
            }

            try
            {
                var result = await _moduleLessonsRepository.Delete(existingModule);

                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<bool>("Error deleting module");

                return BaseResponseHelper.HandleSuccessfulRequest(true);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Error create new module");
            }
        }
        public async Task<BaseResponse<ModuleLessons>> ChangeAvailableModule(int moduleId, bool isAvailable)
        {
            var existingModule = await _moduleLessonsRepository.GetById(moduleId);
            if (existingModule == null)
            {
                return BaseResponseHelper.HandleNotFound<ModuleLessons>("Module not found");
            }

            try
            {
                bool result = await _moduleLessonsRepository.ChangeAvailableModule(existingModule, isAvailable);
                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<ModuleLessons>("Error changing availability");

                return BaseResponseHelper.HandleSuccessfulRequest(existingModule);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<ModuleLessons>("Error changing availability");
            }
        }
        
        public async Task<BaseResponse<ModuleLessons>> GetModule(int moduleId)
        {
            try
            {
                var module = await _moduleLessonsRepository.GetById(moduleId);
                if (module == null)
                    return BaseResponseHelper.HandleNotFound<ModuleLessons>("Module not found");

                return BaseResponseHelper.HandleSuccessfulRequest(module);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<ModuleLessons>("Error fetching module");
            }
        }
       
        public async Task<BaseResponse<Lesson>> AddLesson(int moduleId, Lesson lesson)
        {
            if (lesson == null)
            {
                return BaseResponseHelper.HandleBadRequest<Lesson>("Bad parameters in request");
            }

            var currentModule = await _moduleLessonsRepository.GetById(moduleId);

            if (currentModule == null)
            {
                return BaseResponseHelper.HandleNotFound<Lesson>("The specified module was not found");
            }

            try
            {
                var newLesson = await _moduleLessonsRepository.AddLessonToModule(moduleId, lesson);

                if (newLesson == null)
                    return BaseResponseHelper.HandleInternalServerError<Lesson>("Error adding lesson");

                return BaseResponseHelper.HandleSuccessfulRequest(newLesson);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<Lesson>("Server error");
            }
        }
        public async Task<BaseResponse<bool>> DeleteLesson(int moduleId, Lesson lesson)
        {
            if (lesson == null)
            {
                return BaseResponseHelper.HandleBadRequest<bool>("Bad parameters in request");
            }

            var currentModule = await _moduleLessonsRepository.GetById(moduleId);

            if (currentModule == null)
            {
                return BaseResponseHelper.HandleNotFound<bool>("The specified module was not found");
            }

            try
            {
                bool result = await _moduleLessonsRepository.DeleteLessonFromModule(moduleId, lesson);
                if (!result)
                    return BaseResponseHelper.HandleInternalServerError<bool>("Error deleting lesson");

                return BaseResponseHelper.HandleSuccessfulRequest(true);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Error deleting lesson");
            }
        }
        public async Task<BaseResponse<bool>> DeleteAllLesson(int moduleId, List<Lesson> lessons) //TODO: реалізувати перевірки
        {
            if (lessons == null || lessons.Any(l => l == null))
                return BaseResponseHelper.HandleBadRequest<bool>("Invalid lessons list");

            var currentModule = await _moduleLessonsRepository.GetById(moduleId);
            
            if (currentModule == null)
                return BaseResponseHelper.HandleNotFound<bool>("Module not found");

            try
            {
                foreach (var lesson in lessons)
                {
                    await _moduleLessonsRepository.DeleteLessonFromModule(moduleId, lesson);
                }

                return BaseResponseHelper.HandleSuccessfulRequest(true);
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<bool>("Error deleting lessons");
            }
        }

        public async Task<BaseResponse<IEnumerable<Lesson>>> GetAllLessonThisModule(int moduleId, Lesson lesson)
        {

            try
            {
                var currentModule = await _moduleLessonsRepository.GetModuleByIdWithLessons(moduleId);

                if (currentModule == null)
                    return BaseResponseHelper.HandleNotFound<IEnumerable<Lesson>>("Module not found");

                return new BaseResponse<IEnumerable<Lesson>>
                {
                    Data = currentModule.Lessons,
                    StatusCode = MyStatusCode.OK
                };
            }
            catch (Exception)
            {
                return BaseResponseHelper.HandleInternalServerError<IEnumerable<Lesson>>("Error fetching lessons");
            }
        }
    }
}

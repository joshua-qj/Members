using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.StudentUsecases
{
    public class ViewStudentUseCase : IViewStudentUseCase {
        private readonly IStudentRepository _studentRepository;

        public ViewStudentUseCase(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }

        public async Task<Student> ExecuteAsync(int studentId) {
            return await _studentRepository.GetStudentByIdAsync(studentId);
        }

    }
}

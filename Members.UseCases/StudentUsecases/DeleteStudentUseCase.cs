using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.StudentUsecases
{
    public class DeleteStudentUseCase : IDeleteStudentUseCase {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentUseCase(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }

        public async Task ExecuteAsync(Student student) {
            await _studentRepository.DeleteStudentAsync(student);
        }
    }
}

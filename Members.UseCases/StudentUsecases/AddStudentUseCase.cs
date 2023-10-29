using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.StudentUsecases
{
    public class AddStudentUseCase : IAddStudentUseCase {
        private readonly IStudentRepository _studentRepository;

        public AddStudentUseCase(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }

        public async Task ExecuteAsync(Student student) {
            await _studentRepository.AddStudentAsync(student);
        }
    }
}


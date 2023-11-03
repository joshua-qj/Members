using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.StudentUseCases {
    public class DeleteStudentUseCase : IDeleteStudentUseCase {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentUseCase(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }

        public async Task ExecuteAsync(int studentId) {
            await _studentRepository.DeleteStudentAsync(studentId);
        }
    }
}

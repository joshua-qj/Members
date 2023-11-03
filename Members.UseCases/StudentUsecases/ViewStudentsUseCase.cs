using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.StudentUseCases {
    public class ViewStudentsUseCase : IViewStudentsUseCase {
        private readonly IStudentRepository _studentRepository;

        public ViewStudentsUseCase(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> ExecuteAsync(string filterText) {
            return await _studentRepository.GetStudentsAsync(filterText);
        }
    }
}

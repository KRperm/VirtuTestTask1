using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController, Route("api/[controller]"), EnableCors]
    public class RecordsController : ControllerBase
    {
        public IRecordsService RecordsService { get; }
        private IMapper Mapper { get; }

        public RecordsController(IRecordsService recordsService, IMapper mapper)
        {
            RecordsService = recordsService;
            Mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var records = RecordsService.GetAll();
            var dtos = Mapper.Map<IEnumerable<RecordDto>>(records);
            return Ok(dtos);
        }

        [HttpPost]
        public IActionResult AddRecord(RecordRequest request)
        {
            var newRecord = Mapper.Map<Record>(request);
            newRecord.Id = Guid.NewGuid();
            RecordsService.Create(newRecord);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditRecord(Guid id, RecordRequest request)
        {
            var updatedRecord = RecordsService.Get(id);
            if (updatedRecord is null)
                return NotFound();

            if (request.Name is not null)
                updatedRecord.Name = request.Name;
            if (request.DateOfBirth is not null)
                updatedRecord.DateOfBirth = (DateTime)request.DateOfBirth;
            if (request.Phone is not null)
                updatedRecord.Phone = request.Phone;

            RecordsService.Update(updatedRecord);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveRecord(Guid id)
        {
            var recordToDelete = RecordsService.Get(id);
            if (recordToDelete is null)
                return NotFound();

            RecordsService.Delete(recordToDelete);
            return Ok();
        }

        [HttpOptions]
        public IActionResult PreflightRoute()
        {
            return NoContent();
        }
    }
}
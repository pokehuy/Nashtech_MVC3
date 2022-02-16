using asp_a2.Repository;

namespace asp_a2.Models;

public class PersonModel : IPersonModel {
    public int? Id {get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public int? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? BirthPlace { get; set; }
    public bool? IsGraduated { get; set; }

    static List<PersonModel> listPersons = new List<PersonModel>
        {
            new PersonModel{
                Id = 1,
                FirstName = "Nguyen",
                LastName = "Nam Phuong",
                Gender = "Male",
                DateOfBirth = 2001,
                PhoneNumber = "0123456778",
                BirthPlace = "Ha noi",
                IsGraduated = false
            },
            new PersonModel{
                Id = 2,
                FirstName = "Phuong",
                LastName = "Viet Hoang",
                Gender = "Male",
                DateOfBirth = 1999,
                PhoneNumber = "01234545667",
                BirthPlace = "Nam dinh",
                IsGraduated = false
            },
            new PersonModel{
                Id = 3,
                FirstName = "Trinh",
                LastName = "Hong Nhung",
                Gender = "Female",
                DateOfBirth = 1999,
                PhoneNumber = "01298332132",
                BirthPlace = "Thanh hoa",
                IsGraduated = true
            }
        };

    public List<PersonModel> List(){
        return listPersons.OrderBy(p => p.Id).ToList();
    }

    public void Create(PersonModel per) {
        var list = listPersons.Where(p => p.Id == per.Id);
        if(list.Count() == 0){
            listPersons.Add(per);
        }
    }
    public void Update(PersonModel per) {
        var person = listPersons.Where(p => p.Id == per.Id).FirstOrDefault();
        if(person != null){
            person.FirstName = per.FirstName;
            person.LastName = per.LastName;
            person.Gender = per.Gender;
            person.DateOfBirth = per.DateOfBirth;
            person.PhoneNumber = per.PhoneNumber;
            person.BirthPlace = per.BirthPlace;
            person.IsGraduated = per.IsGraduated;
        }
    }
    public PersonModel Delete(int id){
        var person = listPersons.Where(p => p.Id == id).FirstOrDefault();
        if(person != null){
            listPersons.Remove(person);
        }
        return person;
    }
}
using System;

namespace DisposableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var peopleRepo = new PeopleRepository(new MyContext()))
            {
                var personToAdd = new Person {FirstName = "John", LastName = "Smith"};
                peopleRepo.Create(personToAdd);
            }

            var peopleRepository= new PeopleRepository(new MyContext());
            var person = peopleRepository.Get(1);
            peopleRepository.Dispose();
            try
            {
                person = peopleRepository.Get(1);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}

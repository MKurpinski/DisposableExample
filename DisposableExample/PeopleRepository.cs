using System;

namespace DisposableExample
{
    public class PeopleRepository : IDisposable
    {
        private readonly MyContext _context;
        private bool _isDisposed;

        public PeopleRepository(MyContext context)
        {
            _context = context;
        }

        public Person Get(int id)
        {
            CheckIfDisposed();
            var result = _context.People.Find(id);
            return result;
        }
        public void Create(Person person)
        {
            CheckIfDisposed();
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _context?.Dispose();
                _isDisposed = true;
            }
        }

        protected void CheckIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("Object cannot be used. It has beeen already disposed");
            }
        }
    }
}

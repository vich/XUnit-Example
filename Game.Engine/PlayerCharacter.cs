using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Game.Engine.Annotations;

namespace Game.Engine
{
    public class PlayerCharacter : INotifyPropertyChanged
    {
        #region Members

        private int _health = 100;

        #endregion

        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string NickName { get; set; }
        public bool IsNoob { get; set; }

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                OnPropertyChanged();
            }
        }

        public IList<string> Weapons { get; set; }

        public event EventHandler<EventArgs> PlayerSlept;

        #endregion Properties

        #region Constractur

        public PlayerCharacter()
        {
            //FirstName = GenerateRandomFirstName();
            IsNoob = true;
            CreateStartingWeapons();
        }

        #endregion Constractur

        #region Public Methods

        public void Sleep()
        {
            var healthIncrease = CalculateHealthIncrease();
            Health += healthIncrease;
            OnPlayerSlept(EventArgs.Empty);
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(1, Health -= damage);
        }

        #endregion Public Methods

        #region Private Methods

        private void CreateStartingWeapons()
        {
            Weapons = new List<string>
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };
        }

        // private string GenerateRandomFirstName()
        // {
        //     throw new NotImplementedException();
        // }

        private void OnPlayerSlept(EventArgs e)
        {
            PlayerSlept?.Invoke(this, e);
        }

        private int CalculateHealthIncrease()
        {
            var rnd = new Random();
            return rnd.Next(1, 101);
        }

        #endregion Private Methods


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
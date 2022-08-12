﻿using ChessTournament.BLL.DTO;
using ChessTournament.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Interfaces
{
    public interface ITournamentService
    {
        public IEnumerable<Tournament> GetAll();
        public Tournament GetById(int id);
        public int Insert(TournamentCreateForm tcf);
        public bool Update(TournamentUpdateForm tcf);
        public bool Delete(int id);

    }
}

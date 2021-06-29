using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Data.Repositories;
using TMulticom.Test.FakeRepositories;


namespace TMulticom.Test.ControllerTests
{
    [TestClass]
    public class AmigoControllerTests
    {
        private AmigoRepositoryFake _repository = new AmigoRepositoryFake();
        
        public AmigoControllerTests()
        {
        }

        [TestMethod] 
        public void Inserir_Amigo_Sucesso()
        {
            
        }
    }
}

using AIIVE.ES.NEST.Training;
using FluentAssertions;
using System;
using Xunit;

namespace Aiive.Nest.Training.IntegrationTest
{
    public class SamplesTests
    {
        private readonly Helpers _helpers;

        private const string INDEX_DEFAULT = "kibana_sample_data_ecommerce";

        public SamplesTests()
        {
            _helpers = new Helpers();
        }

        [Fact]
        public void Teste0()
        {
            string index1 = "ecommerce";
            string index2 = "my-ecommerce";

            var client = _helpers.CreateElasticClient(index1);
            var result = client.Search<Sample>(s => s.MatchAll());

            var client2 = _helpers.CreateElasticClient(index2);
            var result2 = client2.Search<Sample>(s => s.MatchAll());
            result2.Should().NotBeNull();
            result.Should().NotBeNull();

        }

        /// <summary>
        /// 1. Quantos documentos esse índice tem?
        /// </summary>
        [Fact]
        public void Teste1()
        {
            var client = _helpers.CreateElasticClient(INDEX_DEFAULT);

            var result = client.Search<Sample>(s => s.MatchAll().Size(0));

            result.Total.Should().Be(4675);
        }

        /// <summary>
        /// 2. Como podemos criar um alias para esse índice?
        /// </summary>
        [Fact]
        public void Teste2() 
        {
            var client = _helpers.CreateElasticClient("kibana_sample_data_ecommerce");

            var result = client.Indices.PutAlias(INDEX_DEFAULT, "comercio2");

            result.ApiCall.Success.Should().BeTrue();   

        }

        /// <summary>
        /// 3. Como verificamos o mapeamento desse índice?
        /// </summary>
        [Fact]
        public void Teste3() 
        {
            var client = _helpers.CreateElasticClient("comercio");
            var result = client.Indices.GetMapping<Sample>();

            result.Indices.Count.Should().BeGreaterThan(0);
        }

        /// <summary>
        /// 4. Como verificamos o mapeamento de um campo desse índice específico?
        /// </summary>
        [Fact]
        public void Teste4() { }

        /// <summary>
        /// 5.1 Primeiro precisamos mapear a propriedade "products" para ser do type "nested".
        /// </summary>
        [Fact]
        public void Teste5_1() { }

        /// <summary>
        ///  5.2 Agora vamos transferir o índice ecommerce para o my-ecommerce.
        /// </summary>
        [Fact]
        public void Teste5_2() { }

        /// <summary>
        ///    5.3 Vamos verificar como ficou o mapeamento do nosso my-ecommerce. Fazendo a nossa query de mapeamento vemos agora que produtos está com type nested.
        /// </summary>
        [Fact]
        public void Teste5_3() { }

        /// <summary>
        /// 6. Qual a diferença na pesquisa?
        /// </summary>
        [Fact]
        public void Teste6() { }

        /// <summary>
        /// 7. Nosso gerente de marketing perguntou se nós vendemos mais para pessoas que se identificam com o gênero Masculino ou Female.

        /// </summary>
        [Fact]
        public void Teste7() 
        {
            var client = _helpers.CreateElasticClient("comercio");

            var result = client.Search<Sample>(s =>
            s.Aggregations(agg => agg.Terms("gender_terms", t =>
            t.Field(f => f.CustomerGender)
            .Missing("N/A")
            .MinimumDocumentCount(0)
            .Order(o => o.KeyAscending()))));

            result.Aggregations.Count.Should().Be(1);
        }

        /// <summary>
        /// 8. Agora ele perguntou pra gente quanto nós vendemos para cada gênero.
        /// </summary>
        [Fact]
        public void Teste8()
        {

        }


        [Fact]
        public void Teste9()
        {
            var client = _helpers.CreateElasticClient("comercio");

            var result = client.Search<Sample>(s => s.Query(q => q.Match(m => m.Field(f => f.CustomerFullName).Query("Eddie"))));
        }

    }
}

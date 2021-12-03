Para esses exercícios vamos utilizar o indice de sample do kibana. Vamos fazer o passo a passo juntos.

1.  Quantos documentos esse índice tem?

```
GET /kibana_sample_data_ecommerce/_search
{
  "size": 0, 
  "query": {
    "match_all": {}
  }
}
```

2.  Como podemos criar um alias para esse índice?

```
PUT /kibana_sample_data_ecommerce/_alias/comercio
```

3.  Como verificamos o mapeamento desse índice?

```
GET /comercio2/_mapping
```

4.  Como verificamos o mapeamento de um campo desse índice específico?

```
GET /comercio/_mapping/field/day_of_week
```

5.  Pelo que vemos products nesse índice não é do tipo nested. Vamos criar um novo índice com esse mapeamento

    5.1 Primeiro precisamos mapear a propriedade "products" para ser do type "nested".

    ```
    PUT /my-comercio
    {
      "mappings": {
        "properties": {
          "products": {
            "type": "nested"
          }
        }
      }
    }
    ```

    5.2 Agora vamos transferir o índice comercio para o my-comercio.
    
    ```
    POST _reindex
    {
      "source": {
        "index": "comercio"
      },
      "dest": {
        "index": "my-comercio"
      }
    }
    ```

    5.3 Vamos verificar como ficou o mapeamento do nosso my-comercio. Fazendo a nossa query de mapeamento vemos agora que
    produtos está com type nested.

6.  Qual a diferença na pesquisa?

```
GET /comercio/_search
{
  "size": 0,
  "_source": ["products"],
  "query": {
    "bool": {
      "must": [
        {
          "match": {
            "products.manufacturer": "Elitelligence"
          }
        },
        {
          "match": {
            "products.min_price": 11.75
          }
        }
        ]
    }
  }
}
```

```
GET /my-comercio/_search
{
  "size":0,
  "_source": ["products"],
  "query": {
    "nested": {
     "path": "products",
     "query": {
       "bool": {
         "must": [
           {
             "match": {
               "products.manufacturer": "Elitelligence"
             }
           },
           {
             "match": {
               "products.min_price": 11.75
             }
           }
           ]
       }
     }
    }
  }
}
```
<b>Podemos perceber que a quantidade de retorno foi menor. Vocês lembram porque?</b>

6. Nosso gerente de marketing perguntou se nós vendemos mais para pessoas que se identificam com o gênero Masculino ou Feminino.

```
GET /comercio/_search
{
  "size": 0,
  "aggs": {
    "gender_terms": {
      "terms": {
        "field": "customer_gender",
        "missing": "N/A",
        "min_doc_count": 0,
        "order": {
          "_key": "asc"
        }
      }
    }
  }
}
```

7. Agora ele perguntou pra gente quanto nós vendemos para cada gênero.

8. Qual seria a quantidade de roupas compradas dentro de intervalos?

9. Vamos separar a quantidade de taxas por intervalos.

10. O que significa Global?


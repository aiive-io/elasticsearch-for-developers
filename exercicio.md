Para esses exercícios vamos utilizar o indice de sample do kibana. Vamos fazer o passo a passo juntos.

1.  Quantos documentos esse índice tem?

2.  Como podemos criar um alias para esse índice?

3.  Como verificamos o mapeamento desse índice?

4.  Como verificamos o mapeamento de um campo desse índice específico?

5.  Pelo que vemos products nesse índice não é do tipo nested. Vamos criar um novo índice com esse mapeamento

    5.1 Primeiro precisamos mapear a propriedade "products" para ser do type "nested".

    5.2 Agora vamos transferir o índice ecommerce para o my-ecommerce.

        5.3 Vamos verificar como ficou o mapeamento do nosso my-ecommerce. Fazendo a nossa query de mapeamento vemos agora que

    produtos está com type nested.

6.  Qual a diferença na pesquisa?

<b>Podemos perceber que a quantidade de retorno foi menor. Vocês lembram porque?</b>

6. Nosso gerente de marketing perguntou se nós vendemos mais para pessoas que se identificam com o gênero Masculino ou Female.

7. Agora ele perguntou pra gente quanto nós vendemos para cada gênero.

8. Qual seria a quantidade de roupas compradas dentro de intervalos?

9. Vamos separar a quantidade de taxas por intervalos.



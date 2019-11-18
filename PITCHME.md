---?color=linear-gradient(-45deg, rgb(22, 34, 42) 50%, rgb(58, 96, 115) 40%)

# Découverte de GraphQL


---

## 1 - Présentation de GraphQL 

## 2 - Les différentes approches

## 3 - Place au code


---

## Présentation de GraphQL 

+++

- Crée par Facebook en 2012

- Open source depuis 2015

- Language de requetage de données

- Utilisé par Facebook, Airbnb, GitHub, Audi, Paypal, Twitter

+++

### GraphQl une vision differente de REST

----

Graphql apporte une vision differente de la communication client / serveur 
Ne s'appuie pas sur le protocole http comme REST

+++

Pour rappel REST lui calque son fonctinnement sur HTTP:

@ul
    - une ressource = une url
    - réutilisation des verbes d’action(GET, PUT, …)
    - réutilisation des codes de statut (200, 404, …)
@ulend

+++

@snap[west text-08]
Pour GraphQl l'approche est differente: 

@ul
    - Une URL unique (généralement /graphql)
    - requète POST
    - Status toujours OK (200), sauf exception lié a l'authentification qui sera un 401 UNAUTHORIZED  
@ulend

L'ensemble des informations utiles sont donc contenu dans le BODY, y compris les erreurs survenues.

@snapend 

+++

@snap[west text-08]
Des données adaptés au client:

    La force de graphql réside dans le fait que le client peut spécifié les données qu'il souhaite récupéré. 
    Cas d'usage: 
    Pour afficher une liste d'utilisateur, on ne souhaite que récupérer le nom, le prénom et la photo de profil
    Pour afficher l'utilisateur en lui meme, on désire plus de données, les amis en communs, l'age, etc.

    En REST, deux solutions existents:
        - Laisser le client trier et afficher les données qu'il souhaite
        - Adapter chaque endpoint selon les données que le client désire 
@snapend 

+++

Des Graphes
    En GraphQl, le client va envoyer une requete comme ceci:

    ```
    GET /graphql

    body: query {
        //MAIL
        mails {
            id
            subject
            //USER
            sender {
                firstname
                lastname
            }
        }
    }
    ```

Chaque donnée permet d’accéder dynamiquement à d’autres données et ainsi de théoriquement récupérer un graphe complet.
Théoriquement car cout serveur plus important, si beaucoup d'imbrication.

+++

Le schéma

Mettre en place une API GraphQL nécessite l’écriture d’un schéma spécifique sur le serveur; 
Celui-ci définit les demandes en lecture (query) et en écriture (mutation).
Le client peut donc demander au serveur les informations qu'il désire contenu dans le schéma.

+++

Une documentation automatique du schéma d’API

GraphQL fournit de base un mécanisme d’introspection permettant de ‘découvrir’ l’API fournie par un serveur donné.
Grace a des outils tel que graphql-cli, ou bien encore graphiql, il est possible d'explorer le schéma.

---

## Les différentes approches

+++

## Schéma first approche


---

Maintenant place au code 

Le but est de créer un API GraphQL from scratch
L'approche sera orienté données, création de la strucutre des données en amont . 
La structure sera simple une API permettant de gérer une TodoList.

+++

@snap[north-east span-100]
@box[bg-purple text-white](Creer un nouvelle solution:#`dotnet new sln`)
@snapend

@snap[east span-100]
@box[bg-orange text-white](Et deux projet:#`dotnet new classlib TodoList`</br>`dotnet new webapi -n WebApiTodoList`)
@snapend

@snap[south-east span-100]
@box[bg-pink text-white](On les ajoutent a la solution#`dotnet sln add TodoList`</br>`dotnet sln add WebApiTodoList`)
@snapend

+++ 

Créer tout les fichiers necessaires:

powershell:

```

cd TodoList

mkdir Types

cd .\Types\

New-Item -ItemType file TodoItem.cs

New-Item -ItemType file TodoItemInterface.cs

New-Item -ItemType file SecondaryTodo.cs

New-Item -ItemType file ImportantTodo.cs

New-Item -ItemType file StatusEnum.cs

```

+++?code=TodoList/Types/TodoItem.cs&lang=csharp

+++?code=TodoList/Types/TodoItemInterface.cs&lang=csharp


---




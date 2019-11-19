---?color=linear-gradient(-45deg, rgb(22, 34, 42) 50%, rgb(58, 96, 115) 40%)

# Découverte de GraphQL


---
@transition[slide-in slide-out]

### 1 - Présentation de GraphQL 

### 2 - Les différentes approches

### 3 - Place au code


---

@transition[slide-in slide-out]

## Présentation de GraphQL 

+++

@transition[slide-in slide-out]

- Crée par Facebook en 2012

- Open source depuis 2015

- Language de requetage de données

- Utilisé par Facebook, Airbnb, GitHub, Audi, Paypal, Twitter

+++

@transition[slide-in slide-out]

#### GraphQl une vision differente de REST
----
@snap[text-left]
Graphql apporte une vision differente de la communication client / serveur.
</br></br>
Utilisation des Query et Mutation:

- Query: Recupération de données
- Mutation: Modification de données

@snapend

+++
@transition[slide-in slide-out]

Pour rappel REST lui calque son fonctinnement sur HTTP:

<br>
- une ressource = une url
- réutilisation des verbes d’action(GET, PUT, …)
- réutilisation des codes de statut (200, 404, …)


+++
@transition[slide-in slide-out]

Pour GraphQl l'approche est differente: 

<br>
- Une URL unique (généralement /graphql)
- requète POST
- Status toujours OK (200), sauf exception lié a l'authentification qui sera un 401 UNAUTHORIZED  

<br>
L'ensemble des informations utiles sont donc contenu dans le BODY, 
y compris les erreurs survenues.



+++
@transition[slide-in slide-out]
@snap[west text-08]
Des données adaptés au client:

La force de graphql réside dans le fait que le client peut spécifié les données qu'il souhaite récupéré. 
Cas d'usage: </br>
- Pour afficher une liste d'utilisateur, on ne souhaite que récupérer le nom, le prénom et la photo de profil
- Pour afficher l'utilisateur en lui meme, on désire plus de données, les amis en communs, l'age, etc.
</br></br>
En REST, deux solutions existents:
- Laisser le client trier et afficher les données qu'il souhaite
- Adapter chaque endpoint selon les données que le client désire 
@snapend 




+++?color=white
@transition[slide-in slide-out]

@snap[north span-100]
#### Des Graphes

Le client va envoyer une requete comme ceci:
@snapend

@snap[south-west span-30 text-08]
```
GET /graphql

body: query {
    mails {
        id
        subject
        sender {
            firstname
            lastname
        }
    }
}
```
@snapend 

@snap[south-east span-60 text-left text-06]
Chaque donnée permet d’accéder dynamiquement à d’autres données et ainsi de théoriquement récupérer un graphe complet.

Théoriquement car cout serveur plus important, si beaucoup d'imbrication.
@snapend





+++

#### Le schéma
----


Mettre en place une API GraphQL nécessite l’écriture d’un schéma spécifique sur le serveur.</br>

Celui-ci définit les typedefs et les resolvers:

- les **typedefs** définissent l'ensemble des types du schéma.

- les **resolvers** sont les demandes en lecture (**query**) et en écriture (**mutation**).</br>

Le client peut donc demander au serveur les informations qu'il désire contenu dans le schéma.</br>





+++
Definir un schema

```
type Project {

  name: String

  tagline: String

  contributors: [User]

}
````
+++
Requeter les données désirées: 

```
{

  project(name: "GraphQL") {

    tagline

  }

}
```
+++
Recupérer des résultats: 

```
{

  "project": {

    "tagline": "A query language for APIs"

  }

}
```

+++

#### Une documentation automatique du schéma d’API
----

GraphQL fournit de base un mécanisme d’introspection permettant de ‘découvrir’ l’API fournie par un serveur donné.
</br></br>
Grace a des outils tel que **graphql-cli**, ou bien encore **graphiql**, il est possible d'explorer le schéma.

+++

![Schema](/assets/image/schema.png) 

+++
#### Différentes sources de données
----

Vous pouvez récuperer des données de plusieurs source (REST endpoint, Database).
<br><br>
Le schéma va se focaliser sur ce que désire récupérer le client et en abstraire son origine 
<br><br>
L'implémentation d'une query appelant une autre API est tout a fait possible.

+++

@snap[south span-80]

![GraphQLSHEMA](/assets/image/graphql1.png)

@snapend

---

## Les différentes approches

+++

## Schéma first approche

+++
#### La redaction du schéma avant tout

----
Faire de la conception de schéma une priorité du processus de développement.
</br></br>
Le schema est rédigé en une seul version texte qui est ensuite parsé.
</br></br>
Possibilités de splitté les fichiers et de les merger avant executoin du schéma
</br></br>
Lisibilité du schéma claire.
+++

## Code first approche (2019 +)
Programmé a la main, on defini un schéma clairement typé, avec des GraphQLObject.
</br></br>
Plus facile pour l'autocomplétion des IDE.

---

#### Maintenant place au code
----

Le but est de créer un API GraphQL from scratch
</br></br>
L'approche sera orienté données, création de la strucutre des données en amont . </br></br>
La structure sera simple une API permettant de gérer une TodoList.

+++

## Première partie:

----

@ol

- Objets
- Jeu de données
- TypeGraphQL
- Query
- Mutation
- Schema

@olend

+++

## Seconde partie:

----

@ol

- Démarrage de l'API
- Découverte de `ui/playground`

@olend

+++

#### Creer un nouvelle solution:

`dotnet new sln`

</br>
#### Deux projet:

`dotnet new classlib TodoList`

`dotnet new webapi -n WebApiTodoList`

</br>
#### On les ajoutent a la solution

`dotnet sln add TodoList`

`dotnet sln add WebApiTodoList`

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
+++

Créer tout les fichiers necessaires:

@fa[folder](TodoList)
 * @fa[folder](Types)
    *   @fa[file-code](TodoItem.cs)
    *   @fa[file-code](TodoItemInterface.cs)
    *   @fa[file-code](SecondaryTodo.cs)
    *   @fa[file-code](ImportantTodo.cs)
    *   @fa[file-code](StatusEnum.cs)
 * @fa[file-code](TodoListData.cs)
 * @fa[file-code](TodoListQuery.cs)
 * @fa[file-code](TodoListMutation.cs)
 * @fa[file-code](TodoListSchema.cs)
@fa[folder](WebApiTodoList)

+++

### Creation des objets

Une classe abstraite TodoItem qui contient les proriétés:
- ID
- Name 
- Description
- RelatedTo
<br>
Une classe ImportantTodo qui hérite de TodoItem
<br>
Une classe SecondaryTodo qui hérite de TodoItem

[TodoItem](https://raw.githubusercontent.com/pipic1/GraphQLDotNet-API/master/TodoList/Types/TodoItem.cs)

+++?code=TodoList/Types/TodoItem.cs&lang=csharp

+++

### Creation de l'interface avec GraphQL

----
Créer une interface TodoItemInterface.cs qui hérite de InterfaceGraphType<TodoItem>
</br>
Cette classe permet de décrire l'ensemble des champs
</br>
Le constructeur ne prends aucun argument

[TodoItemInterface](https://raw.githubusercontent.com/pipic1/GraphQLDotNet-API/master/TodoList/Types/TodoItemInterface.cs)

+++?code=TodoList/Types/TodoItemInterface.cs&lang=csharp

+++

#### Créer un type GraphQL pour la classe ImportantTodo et SecondaryTodo

----
Créer une classe ImportantType qui hérite de ObjectGraphType<ImportantTodo>
    
Cette classe permet de décrire l'ensemble des champs

Le constructeur prends le gestionnaire des données en argument (TodoListData)

[ImportantType](https://raw.githubusercontent.com/pipic1/GraphQLDotNet-API/master/TodoList/Types/ImportantType.cs)

[SecondaryType](https://raw.githubusercontent.com/pipic1/GraphQLDotNet-API/master/TodoList/Types/SecondaryType.cs)

+++?code=TodoList/Types/ImportantType.cs&lang=csharp

+++

#### Création de l'enum du status d'un todo

----
Créer une enum: Priority, avec trois valeurs ( LOW, MEDIUM, HIGH )

Créer une classe: PriorityEnum qui hérite de EnumerationGraphType<Priority>
    
Son constructeur set les proriétés Name, Description.

Ainsi que l'ensemble des valeurs de l'enum comme suit:

`AddValue("LOW", "The task is not started yet", 1);`

[StatusEnum](https://raw.githubusercontent.com/pipic1/GraphQLDotNet-API/master/TodoList/Types/StatusEnum.cs)

+++?code=TodoList/Types/StatusEnum.cs&lang=csharp

+++



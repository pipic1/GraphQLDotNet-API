---?color=linear-gradient(-45deg, rgb(22, 34, 42) 50%, rgb(58, 96, 115) 40%)

# Découverte de GraphQL


---

### - Présentation

### - Les différentes approches

### - Codons!


---

## Présentation

---


+++

- Un langage de requetage de données 

- Un schema clairement défini

- Query : recupération des données

- Mutation : modification de données


+++

## Première étape 

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


---

## Les différentes approches

+++

## Schéma first approche


+++

## Code first approche

+++


## TEST 1 
## TEST 1 


+++

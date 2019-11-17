---?color=linear-gradient(-45deg, rgb(22, 34, 42) 50%, rgb(58, 96, 115) 40%)

# Découverte de GraphQL


---

## - Présentation

## - Les différentes approches

## - Codons!


---

## Présentation

+++

- Crée par Facebook en 2012

- Open source depuis 2015

- Language de requetage de données

- Utilisé par Facebook, Airbnb, GitHub, Audi, Paypal, Twitter

+++

- Un schema clairement défini

- Query : recupération des données

- Mutation : modification de données

- Subscription : abonnement ( web socket 
)


+++

## Première étape 

@snap[east text-06 text-white span-32] @quote[GitPitch Desktop with speaker notes is AMAZING!](@fa[twitter] @davetapley) @snapend

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

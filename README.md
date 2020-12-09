# WorldOfDarknet
Proyecto web para gestionar las hojas de personajes de rol de la saga [World of darkness](https://www.worldofdarkness.com/)
Se podrá seguir el estado del proyecto desde el trello [World of Darknet](https://trello.com/b/iSr7C0xP/world-of-darknet)

## Tecnologías web
- Frontal: [Vue js](https://vuejs.org/), [Vue Cli](https://cli.vuejs.org/) and [nuxt](https://nuxtjs.org/)
- Backend: Api Rest con [.Net Core 2](https://www.microsoft.com/net/download)

## BBDD
- Amazon Relational Database Service (RDS) (Free 1 año)

## Herramientas

### Herramientas de desarrollo
- [Git](https://git-scm.com/)
- [Visual Studio Code](https://code.visualstudio.com/)
- [Heroku CLI](https://devcenter.heroku.com/articles/heroku-cli)

### Herramientas de BBDD
- Sql Server Express?

### 

## Arquitectura
Trataremos de hacer la parte de backend siguiendo una [arquitectura hexagonal](https://codely.tv/blog/screencasts/arquitectura-hexagonal-ddd/)

## Infraestructura
- [Azure DevOps](https://visualstudio.microsoft.com/es/team-services/)

[![Build Status](https://dev.azure.com/albertortizcape/WorldOfDarknet/_apis/build/status/WorldOfDarknet-CI?branchName=develop)](https://dev.azure.com/albertortizcape/WorldOfDarknet/_build/latest?definitionId=4&branchName=develop)

## Configuración entorno desarrollo

### Preparación Git Remotes para el despliegue
Es necesario añadir dos origenes remotos para los depliegues de front y back en Heroku

``` 
git remote add heroku-api https://git.heroku.com/world-of-dark-net-api.git 

git remote add heroku-front https://git.heroku.com/world-of-darknet-front.git
```

Para comprobar los orígenes remotos
``` 
git remote -v
```

### Heroku command tips

1. Cancel build
   ```
   heroku builds:cancel -a world-of-dark-net-front
   heroku builds:cancel -a world-of-dark-net-api
   ```
# darknet-view

> My splendiferous Nuxt.js project

## Build Setup

```bash
# install dependencies
$ npm install

# serve with hot reload at localhost:3000
$ npm run dev

# build for production and launch server
$ npm run build
$ npm run start

# generate static project
$ npm run generate
```

For detailed explanation on how things work, check out [Nuxt.js docs](https://nuxtjs.org).

## Publicación front en Heroku

```bash
# agregar el repo de front:
$ heroku git:remote -a world-of-darknet-front

# establecer el container, porque js no despliega por defecto en Heroku, y da un error de: No default language could be detected for this app
$ heroku stack:set container --remote heroku-api

# una vez que en el package.json está establecido el comando para desplegar hacer un run publish
# comando en package: "publish": "cd ../../ && git subtree push --prefix game-front/ heroku master || true"
$ npm run publish

# otro comando, parece que para los logs
$ heroku logs --remote heroku-game --tail
```

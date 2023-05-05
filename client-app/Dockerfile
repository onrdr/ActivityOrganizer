FROM node:18-buster

COPY . /app

WORKDIR /app

RUN npm install

RUN npm run build

ENV NPM_CONFIG_PREFIX=/home/node/.npm-global
ENV PATH="/home/node/.npm-global/bin:$PATH"

USER node

RUN npm install -g serve

CMD ["serve", "-s", "build"]
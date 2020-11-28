import http from "../http-common";

class characterService {
  getPack () : Promise<string[]> {
    return new Promise((resolve, reject) => {
      http.get("/characters.json").then(response => {
        resolve(response.data);
      }).catch(error => {
        console.log(error)
        reject()
      });
    })
  }
}

export default new characterService();
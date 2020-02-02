const axios = require('axios')
const request = require('request');
const FormData = require('form-data')
const api = axios.create({
    baseURL: 'https://api.codenation.dev/v1/challenge/dev-ps'
})

module.exports = {
    getCesar: async (token) => {

        resp = await api.get(`/generate-data?token=${token}`)
        return resp.data
    },

    postCesar: async (json, token) => {
        const URL = `https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=${token}`
        const fs = require('fs');
        const newAnswer = fs.createReadStream('C:\\Projetos\\CodeChallengeCcipher\\JavaScript\\answer.json')
        console.log('>> formData >> ', newAnswer);
        request(
            {
              method: 'POST',
              url: URL,
              headers: {
                'Content-Type': 'multipart/form-data'
              },
              formData: {
                answer: newAnswer
              }
            },
            (err, res, body) => {
              if (err) {
                console.log(JSON.stringify(err));
              }
          
              console.log(JSON.stringify(body));
            }
          );
    }


}

const axios = require('axios')

const api  = axios.create({
    baseURL: 'https://api.codenation.dev/v1/challenge/dev-ps'
})  

module.exports = {
    getCesar: async (token) =>{
    
        resp = await api.get(`/generate-data?token=${token}`) 
        return resp.data
    },
    
    postCesar: async (doneCripto, token) =>{
        const data = FormData()
    
        data.append()
    
        // resp = await api.post(`submit-solution?token=${token}`,{
    
        // })
    
    }
}

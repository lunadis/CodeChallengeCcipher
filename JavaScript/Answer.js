const fs = require('fs')
const crypto = require('crypto-js')
const Services = require('./Services/Services')
const TOKEN = '91498adf786e10d487ad56a7b30dc98173ebbf53'
var jsonData;

const InitDecrypt = async (token) =>{
    let data  = await Services.getCesar(token)
    fs.writeFile('./answer.json',JSON.stringify(data), function(err){
        if(err)throw err
        ReadJson()
    })
}

const ReadJson = async () =>{
    let json 
    fs.readFile('./answer.json', function(err, data){
        if(err)throw err
        
        json = JSON.parse(data)

        DecryptData(json)

    })
}
const DecryptData = async (json) =>{
    const{ cifrado, numero_casas } = json
    var decifrado = ""

    console.log(cifrado)

    for(let i = 0; i<cifrado.length; i++){
        let asc
        let letra = cifrado.charAt(i)

        if(letra.charCodeAt(0)  != 46 && letra.charCodeAt(0) != 32  ){

            asc = ((letra.charCodeAt(0) - 97 + (26 - numero_casas)) %26 ) + 97

        }else{
            asc = letra.charCodeAt(0)
        }

        decifrado = decifrado + String.fromCharCode(asc)

    }
    json.decifrado = decifrado

    let bytes = crypto.enc.Utf8.parse(decifrado);
    let hash = crypto.SHA1(bytes)

    console.log(hash)

    json.resumo_criptografico =  hash.toString()

    fs.writeFile('./answer.json',JSON.stringify(json), function(err){
        if(err)throw err
        Services.postCesar(json, TOKEN)
    })
    
}

InitDecrypt(TOKEN)
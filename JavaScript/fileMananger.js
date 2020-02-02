const fs = require('fs')
const Services = require('./Services/Services')
var jsonData

const saveJson = async (token) =>{
    let data  = await Services.getCesar(token)
    fs.writeFile('C:\\Users\\Lopes\\Documents\\answer.json',JSON.stringify(data), function(err){
        if(err)throw err
        readJson()
    })
}

const readJson = async () =>{
    let json 
    fs.readFile('C:\\Users\\Lopes\\Documents\\answer.json', function(err, data){
        if(err)throw err
        
        json = JSON.parse(data)

        setdata(json)

    })
}


const setdata = async (json) =>{
    const{ cifrado, numero_casas } = json
    var descrifrado = ""

    console.log(cifrado)

    for(let i = 0; i<cifrado.length; i++){
        let asc
        let letra = cifrado.charAt(i)

        if(letra.charCodeAt(0)  != 46 && letra.charCodeAt(0) != 32  ){

            //((codigodaletraASC - codletra + desloc) % tamDoAlfabeto) + cod1aletra

            asc = ((letra.charCodeAt(0) - 97 + (26 - numero_casas)) %26 ) + 97

        }else{
            asc = letra.charCodeAt(0)
        }

        descrifrado = descrifrado + String.fromCharCode(asc)

    }

    console.log(descrifrado)

}

saveJson('91498adf786e10d487ad56a7b30dc98173ebbf53')
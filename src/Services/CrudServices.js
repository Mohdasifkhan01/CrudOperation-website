import Configuration from "./../Configuration/Configuration"
import Axios from "./AxiosServices";
const axios=new Axios()
//const Config =new Configuration();
export default class CrudServices{
    CreateRecord(data){
        console.log('data: '+ data+'Url:' +Configuration.CreateRecord)
        return axios.post(Configuration.CreateRecord,data,false)
    }
    ReadRecord(){
        console.log("Url :",Configuration.ReadRecord)
    }

}

import { Usuario } from './Usuario';

export class Medico {
    user: Usuario;
    titulation: Titulacao;
    crm: string;

    //armengo também tem que fazer command xD
    name: string;
    email:string;
}

export enum Titulacao{
    residente =0,
    docente = 1 ,
    efetivo = 2,
}


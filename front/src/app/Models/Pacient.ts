import { Usuario } from './Usuario';
import { ExamRequest } from './ExamRequest';

export class Patient {
    id: number;
    sex: string;
    color: string;
    birthdate: Date;
    user: Usuario;
    examRequests: ExamRequest[]
}

export enum PatientColor {
    Branco = 0,
    Negro = 1,
    Pardo = 2,
    Indigena = 3,
    'Nao Especificado' = 4
}

export enum PatientSex {
    Masculino = 'M',
    Feminino = 'F'
}
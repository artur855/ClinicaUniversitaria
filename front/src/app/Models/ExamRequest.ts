export class ExamRequest {
    id:number;  //n
    hypothesis : string;
    expectedDate : string;
    examName: string; 
    recomendation: string;
    medicCrm : number; //n
    patientId: number;
    medicName: string;
    patientName: number;

}

export enum TypeExam {
    Ecocardiograma = 0,
    Eletrocardiograma = 1,
    Mapa = 2,
    Holter =3
}
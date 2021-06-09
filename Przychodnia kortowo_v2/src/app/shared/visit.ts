export interface IVisits
{
    name: string,
    surname: string,
    phoneNumber: number,
    date: string,
    time: string,
    reason: string,
    doctor: string,
    private: boolean,
    confirmed: string,
    doctorId: string,
    doctorRecommendation: string,
}
export interface Idoctor {

    name: string,
    surname: string,
    medicalSpecialization: string
    phoneNumber: string
  }
  
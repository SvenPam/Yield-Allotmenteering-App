import Bed from '@/models/Bed';

export default class BedRepository {

    private readonly apiUrl = "http://localhost:5001/api/Allotment/";

    public async getBeds(plotId: string, bedId: string): Promise<Bed[]> {
        
        return await this.baseFetch<Bed[]>(`${this.apiUrl}/1/Plot/${plotId}/Bed/`,
        {
            method: "GET"
        });
            
    }

    public async getBed(plotId: string, bedId: string): Promise<Bed> {
        return await this.baseFetch<Bed>(`${this.apiUrl}/1/Plot/${plotId}/Bed/${bedId}`,
        {
            method: "GET"
        })
    }

    private async baseFetch<T>(url: string, request: RequestInit): Promise<T> {
        return await fetch(url, request)
        .then(response => 
            {
                if (response.ok) {
                    return response;
                } else {
                    throw new Error("Failed to get Bed" + response.status)
                }
            })
            .then(response => response.json())
            .then(response => response as T)
    }
}
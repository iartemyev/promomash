import { Injectable } from '@angular/core';
import { RestApiService } from './rest-api.service';
import { Observable } from 'rxjs';
import { IProvinceVm } from '../../model/province.vm';

@Injectable({
	providedIn: 'root',
})
export class ProvinceService {
	public constructor(private restService: RestApiService) {}

	public read(id: string): Observable<IProvinceVm> {
		return this.restService.Get<IProvinceVm>('Province/Read', {
			id,
		});
	}

	public delete(id: string): Observable<void> {
		return this.restService.Delete('Province/Delete', {
			id,
		});
	}

	public list(countryId: string): Observable<IProvinceVm[]> {
		return this.restService.Get<IProvinceVm[]>('Province/List', {
			countryId,
		});
	}
}

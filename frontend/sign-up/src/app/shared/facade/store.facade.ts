import { Injectable } from '@angular/core';
import { LoggerService } from '../service/logger.service';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { IRootState, SignUpAction, SignUpSelector } from '../../store';
import { ICountryVm } from '../model/country.vm';
import { IProvinceVm } from '../model/province.vm';
import { ISignUpDto } from '../model/signup.dto';

@Injectable({
	providedIn: 'root',
})
export class StoreFacade {
	public constructor(private _store$: Store<IRootState>, private _logger: LoggerService) {}

	public selectCountryListLoading(): Observable<boolean> {
		return this._store$.select(SignUpSelector.countryListLoading);
	}

	public selectCountryList(): Observable<ICountryVm[]> {
		return this._store$.select(SignUpSelector.countryList);
	}

	public selectProvinceListLoading(): Observable<boolean> {
		return this._store$.select(SignUpSelector.provinceListLoading);
	}

	public selectProvinceList(): Observable<IProvinceVm[]> {
		return this._store$.select(SignUpSelector.provinceList);
	}

	public countryListLoading() {
		this._store$.dispatch(SignUpAction.CountryListLoading());
	}

	public provinceListLoading(payload: string) {
		this._store$.dispatch(SignUpAction.ProvinceListLoading({ payload }));
	}

	public firstStepData(payload: { login: string; password: string; isAgree: boolean }) {
		this._store$.dispatch(SignUpAction.SignUpStepFirstData({ payload }));
	}

	public signUpLoading(payload: ISignUpDto) {
		this._store$.dispatch(SignUpAction.SignUpLoading({ payload }));
	}
}

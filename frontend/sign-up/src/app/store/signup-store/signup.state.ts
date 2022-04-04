import { ICountryVm } from '../../shared/model/country.vm';
import { IProvinceVm } from '../../shared/model/province.vm';

export const featureKey = 'signUpState';

export interface ISignUpState {
	login: string;
	password: string;
	isAgree: boolean;
	countryListLoading: boolean;
	countryList: ICountryVm[];
	provinceListLoading: boolean;
	provinceList: IProvinceVm[];
	signUpLoading: boolean;
	accessToken: string;
}

export const initialSignUpState: ISignUpState = {
	login: '',
	password: '',
	isAgree: false,
	countryListLoading: false,
	countryList: [],
	provinceListLoading: false,
	provinceList: [],
	signUpLoading: false,
	accessToken: '',
};

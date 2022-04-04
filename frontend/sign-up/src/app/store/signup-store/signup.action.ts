import { createAction, props } from '@ngrx/store';
import { ICountryVm } from '../../shared/model/country.vm';
import { IProvinceVm } from '../../shared/model/province.vm';
import { ISignUpDto } from '../../shared/model/signup.dto';

const COUNTRY_LIST_LOADING = '[SignUp] Country list Loading';
const COUNTRY_LIST_SUCCESS = '[SignUp] Country list Success';
const COUNTRY_LIST_FAILURE = '[SignUp] Country list Failure';

const PROVINCE_LIST_LOADING = '[SignUp] Province list Loading';
const PROVINCE_LIST_SUCCESS = '[SignUp] Province list Success';
const PROVINCE_LIST_FAILURE = '[SignUp] Province list Failure';

const SIGNUP_LOADING = '[SignUp] Sign up query Loading';
const SIGNUP_SUCCESS = '[SignUp] Sign up query Success';
const SIGNUP_FAILURE = '[SignUp] Sign up query Failure';

const SIGNUP_STEP_FIRST_DATA = '[SignUp] First step data';

export const CountryListLoading = createAction(COUNTRY_LIST_LOADING);
export const CountryListSuccess = createAction(
	COUNTRY_LIST_SUCCESS,
	props<{ payload: ICountryVm[] }>(),
);
export const CountryListFailure = createAction(COUNTRY_LIST_FAILURE, props<{ payload: Error }>());

export const ProvinceListLoading = createAction(
	PROVINCE_LIST_LOADING,
	props<{ payload: string }>(),
);
export const ProvinceListSuccess = createAction(
	PROVINCE_LIST_SUCCESS,
	props<{ payload: IProvinceVm[] }>(),
);
export const ProvinceListFailure = createAction(PROVINCE_LIST_FAILURE, props<{ payload: Error }>());

export const SignUpLoading = createAction(SIGNUP_LOADING, props<{ payload: ISignUpDto }>());
export const SignUpSuccess = createAction(SIGNUP_SUCCESS, props<{ payload: string }>());
export const SignUpFailure = createAction(SIGNUP_FAILURE, props<{ payload: Error }>());

export const SignUpStepFirstData = createAction(
	SIGNUP_STEP_FIRST_DATA,
	props<{ payload: { login: string; password: string; isAgree: boolean } }>(),
);
